namespace BankStatementParser.Tests
{
    using Fixie;
    using UglyToad.Fixie.DataDriven;

    public class TestConfiguration : Convention
    {
        public TestConfiguration()
        {
            Classes.NameEndsWith("Tests");

            Methods.Where(method => method.IsVoid());

            Parameters
                .Add<ProvideTestDataFromInlineData>()
                .Add<ProvideTestDataFromMemberData>();
        }
    }
}
