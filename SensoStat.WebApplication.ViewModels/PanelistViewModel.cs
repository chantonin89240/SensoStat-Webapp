using System.ComponentModel.DataAnnotations;

namespace SensoStat.WebApplication.ViewModels;

public class PanelistViewModel
{
    public int Id { get; set; }

    [Required]
    public string CodePanelist { get; set; }

    public List<PublicationViewModel> Publications { get; set; }

    public List<ResponseViewModel> Responses { get; set; }

    public List<PresentationViewModel> Presentations { get; set; }

    public PanelistViewModel()
    {
        this.Publications = new List<PublicationViewModel>();
        this.Responses = new List<ResponseViewModel>();
        this.Presentations = new List<PresentationViewModel>();
    }

    public PanelistViewModel(string codePanelist) : this()
    {
        this.CodePanelist = codePanelist;
    }
}

