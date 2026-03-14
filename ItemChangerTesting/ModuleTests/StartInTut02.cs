using Benchwarp.Data;

namespace ItemChangerTesting.ModuleTests
{
    internal class StartInTut02 : Test
    {
        public override TestMetadata GetMetadata() => new()
        {
            Folder = TestFolder.ModuleTests,
            MenuName = "Start In Tut_02",
            MenuDescription = "Tests a TransitionOffsetStartDef at Tut_02, right1",
            Revision = 2026012300,
        };
        
        public override void Setup(TestArgs args)
        {
            StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
        }
    }
}
