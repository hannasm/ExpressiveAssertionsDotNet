using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveAssertions.Tests {
    public abstract class ExpressiveAssertionsFilesystemBackedTestBase {
        public IntrospectiveAssertionTool _introspective;
        public IAssertionTool _assert;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public virtual void Init()
        {
            _assert = ExpressiveAssertions.Tooling.AssertionRendererTool.Create( 
                CompositeAssertionTool.Create(
                ExpressiveAssertions.Tooling.AssertionRendererTool.Create(
                    TraceLoggingAssertionTool.Create()
                ),
                _introspective = new IntrospectiveAssertionTool(
                    ExpressiveAssertions.Tooling.AssertionRendererTool.Create( 
                    CompositeAssertionTool.Create(
                        TraceLoggingAssertionTool.Create(),
                        ExpressiveAssertions.MSTest.MSTestAssertionTool.Create()
                    )
                    )
                )
                )
            );

            FilesystemAssertionRepository.SetFilesystemFilenameRemovePrefix(_assert, "ExpressiveAssertions.Tests.");
            var assertPath = System.IO.Path.Combine("..", "..", "..", "assertions", 
                FilesystemAssertionRepository.SanitizeFilename(_assert, TestContext.FullyQualifiedTestClassName), 
                FilesystemAssertionRepository.SanitizeFilename(_assert, TestContext.TestName)
            );

            FilesystemAssertionRepository.SetFilesystemAssertionRepositoryPath(_assert, assertPath);
        }

        public void ConfigureAutoAccept() {
            FilesystemAssertionRepository.ConfigureFilesystemAssertionAutoAccept(_assert);
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            // this should be called by each test on it's own for the best 'error reporting experience'
            _introspective.NoneOutstanding();
        }

    }
}