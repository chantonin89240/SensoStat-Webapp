 namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class ResponseFactory
    {
        public static List<Response> GenerateResponse(List<Panelist> panelists, List<Product> products, List<Instruction> instructions)
        {
            List<Response> responses = new List<Response>();
            var faker = new Faker();

            panelists.ForEach(panelist =>
            {
                products.ForEach(product =>
                {
                    instructions.ForEach(instruction =>
                    {
                        var response = new Response(
                            panelist,
                            product,
                            instruction,
                            faker.Lorem.Sentence(),
                            faker.Date.Past()
                            );

                        responses.Add(response);
                    });
                });
            });

            return responses;
        }
    }
}
