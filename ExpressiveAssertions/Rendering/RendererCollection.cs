using System;
using System.Collections;
using System.Collections.Generic;
using ExpressiveAssertions.Data;
namespace ExpressiveAssertions.Rendering
{
  public class RendererCollection : IObjectRenderer, IEnumerable<IObjectRenderer>
  {
    readonly List<IObjectRenderer> _map = new List<IObjectRenderer>();
   
    CyclePreventionRenderer _cyclePreventer = null;
    public void EnableCyclePreventer() {
      _cyclePreventer = new CyclePreventionRenderer();
    }
    public void DisableCyclePreventer() {
      _cyclePreventer = null;
    }

    public void Add(Func<object, bool> test, Func<object, object> render) {
     _map.Add(new LambdaRenderer(test, render));
    }
    public void Add(IObjectRenderer lambda) {
     _map.Add(lambda);
    }
    public void Insert(int index, Func<object, bool> test, Func<object, object> render) {
      _map.Insert(index, new LambdaRenderer(test, render));
    }
    public void Insert(int index, IObjectRenderer lambda) {
      _map.Insert(index, lambda);
    }
    public void Push(Func<object, object> render) {
     _map.Insert(0, new LambdaRenderer(a=>true, render));
    }
    public void Push(Func<object, bool> test, Func<object, object> render) {
     _map.Insert(0, new LambdaRenderer(test, render));
    }
    public void Push(IObjectRenderer lambda) {
     _map.Insert(0, lambda);
    }
    public bool Remove(IObjectRenderer renderer) {
      return _map.Remove(renderer);
    }
    public void Clear() {
      _map.Clear();
    }
    public int Count { get { return _map.Count; } }

    public object Render(ObjectRenderingRequest req) {
      if (_cyclePreventer != null) {
        var res = _cyclePreventer.Render(req);
        if (res != req.RenderTarget && res != req) {
          req = new ObjectRenderingRequest(req.Assertion, req.Renderer, res);
        }
      }
      
      var obj = req.RenderTarget;
      var oldObj = obj;
      foreach (var mapping in _map) {
        if (obj != oldObj && obj != req) {
          req = new ObjectRenderingRequest(req.Assertion, req.Renderer, obj);
          oldObj = obj;
        }
          
        obj = mapping.Render(req); 
      }
      return obj;
    }

    public IEnumerator<IObjectRenderer> GetEnumerator()
    {
      return _map.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
      return _map.GetEnumerator();
    }

    public void RestoreState(ObjectRenderingContext context, object state)
    {
      var state2 = (object[])state;
      var idx = 0;
      if (_cyclePreventer != null) {
        _cyclePreventer.RestoreState(context, state2[idx++]);
      }
      foreach (var mapping in _map) {
        mapping.RestoreState(context, state2[idx++]);
      }
    }

    public object SaveState(ObjectRenderingContext context)
    {
      var cnt = _map.Count;
      if (_cyclePreventer != null) {
        cnt++;
      }
      var result = new object[cnt];

      var idx = 0;
      if (_cyclePreventer != null) {
        result[idx++] = _cyclePreventer.SaveState(context);
      }

      foreach (var mapping in _map) {
        result[idx++] = mapping.SaveState(context);
      }

      return result;
    }
  }
}
