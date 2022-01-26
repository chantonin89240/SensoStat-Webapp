namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class ResponseFactory
    {
        public static Faker<Response> GenerateResponse()
        {
            var CreateResponseFactory = new Faker<Response>()
                .StrictMode(true)
                .RuleFor(p => p.CommentResponse, f => f.Lorem.Paragraph())
                .RuleFor(p => p.DateResponse, f => f.Date.Recent())
                .RuleFor(p => p.Instruction, InstructionFactory.GenerateInstruction().Generate())
                .RuleFor(p => p.Product, ProductFactory.GenerateProduct().Generate())
                .RuleFor(p => p.Panelist, PanelistFactory.GeneratePanelist().Generate());

            return CreateResponseFactory;
        }
    }
}
