namespace SensoStat.Services
{
    using SensoStat.Entities;
    using SensoStat.Models.HttpRequest;
    using SensoStat.Models.HttpResponse;
    using SensoStat.Repository.Contracts;
    using SensoStat.Services.Contracts;

    /// <summary>
    /// .
    /// </summary>
    public class PresentationService : IPresentationService
    {
        private IPresentationRepository _presentationRepository;
        private IProductRepository _productRepository;
        private IPanelistRepository _panelistRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PresentationService"/> class.
        /// </summary>
        /// <param name="presentationRepository">.</param>
        public PresentationService(IPresentationRepository presentationRepository, IProductRepository productRepository, IPanelistRepository panelistRepository)
        {
            this._presentationRepository = presentationRepository;
            this._productRepository = productRepository;
            this._panelistRepository = panelistRepository;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">id de la session.</param>
        /// <returns>liste des présentation en fonction de la session.</returns>
        public IEnumerable<PresentationResponse> FindAllByIdSession(int id)
        {
            var presentationsResponse = new List<PresentationResponse>();

            var presentations = this._presentationRepository.FindByIdSession(id);

            presentations.ToList().ForEach(p =>
            {
                p.Product = this._productRepository.Find(p.IdProduct);
                p.Panelist = this._panelistRepository.Find(p.IdPanelist);
                var presentationResponse = new PresentationResponse(p);

                presentationsResponse.Add(presentationResponse);
            });

            return presentationsResponse;
        }

        public bool MultiCreate(List<PresentationRequest> presentationsRequest)
        {
            List<Presentation> presentations = new List<Presentation>();

            try
            {
                // Création des différents panélistes
                var panelistsCreated = new List<Panelist>();
                var panelists = presentationsRequest.Select(p => p.CodePanelist).Distinct().ToList();
                panelists.ForEach(pan =>
                {
                    var panelist = this._panelistRepository.Add(new Panelist() { CodePanelist = pan });
                    panelistsCreated.Add(panelist);
                });

                // Création des différents produits
                var productsCreated = new List<Product>();
                var products = presentationsRequest.Select(p => p.CodeProduct).Distinct().ToList();
                products.ForEach(prod =>
                {
                    var product = this._productRepository.Add(new Product() { CodeProduct = prod, IdSession = presentationsRequest[0].IdSession });
                    productsCreated.Add(product);
                });

                // Création des présentations
                presentationsRequest.ForEach(p =>
                {
                    var presentation = new Presentation()
                    {
                        Rank = p.Rank,
                        IdProduct = productsCreated.First(prod => prod.CodeProduct == p.CodeProduct).Id,
                        IdPanelist = panelistsCreated.First(pan => pan.CodePanelist == p.CodePanelist).Id,
                    };
                    presentations.Add(presentation);
                });
                this._presentationRepository.AddRange(presentations);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
