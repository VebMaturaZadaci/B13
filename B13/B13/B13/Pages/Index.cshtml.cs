using B13.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace B13.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly KorisnikService _korisnikService;
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Tellmenik.txt");
        public List<Korisnik> _korisnici = new List<Korisnik>();
        public string UnetoIme { get; set; }
        public string UnetoPrezime { get; set; }

        public List<SelectListItem> Imena {  get; set; }
        public List<SelectListItem> Prezimena { get; set; }

        public IndexModel(ILogger<IndexModel> logger, KorisnikService korisnikService)
        {
            _logger = logger;
            _korisnikService = korisnikService;
        }

        public void OnGet()
        {
            _korisnici = _korisnikService.GetAllKorisnici();
            Imena = _korisnikService.GetAllImena(_korisnici);
            Prezimena = _korisnikService.GetAllPrezimena(_korisnici);

        }
    }
}