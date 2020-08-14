using System;

namespace ExpressiveAssertions.Rendering {
  public class DefaultRenderingStack : RendererCollection
  {
    public DefaultRenderingStack() {
      Add(new AnnotationDataRenderer());
      Add(new LiteralRenderingStack());
      Add(new ExpressionValueMappingRenderer());
      Add(new ExpressionRenderer());
      Add(new ExceptionRenderer());
      Add(new DelegateRenderer());
      Add(new CollectionRenderer());
      Add(new FormattableRenderer());
      Add(new ReflectionRenderer());

      EnableCyclePreventer();
    }
  }
  
  public class LiteralRenderingStack : RendererCollection
  {
    public LiteralRenderingStack()
    {
      Add(new LiteralRenderer<sbyte>("G", "[sbyte]", null));
      Add(new LiteralRenderer<byte>("G", "[byte]", null));
      Add(new LiteralRenderer<short>("G", "[short]",null));
      Add(new LiteralRenderer<ushort>("G", "[ushort]",null));
      Add(new LiteralRenderer<int>("G", "[int]",null));
      Add(new LiteralRenderer<uint>("G", "[uint]",null));
      Add(new LiteralRenderer<long>("G", "[long]",null));
      Add(new LiteralRenderer<ulong>("G", "[ulong]",null));
      Add(new LiteralRenderer<float>("R", "[float]",null));
      Add(new LiteralRenderer<double>("R", "[double]",null));
      Add(new LiteralRenderer<decimal>("G99", "[decimal]",null));
      Add(new LiteralRenderer<bool>(null, "[bool]",null));
      Add(new LiteralRenderer<DateTime>("O", "[datetime]'",null));
      Add(new LiteralRenderer<TimeSpan>("G", "[timespan]'",null));
      Add(new CharRenderer());
      Add(new StringRenderer());
      Add(new EnumRenderer());
      Add(new NullRenderer());
      Add(new TypeRenderer());
    }
  }

}
