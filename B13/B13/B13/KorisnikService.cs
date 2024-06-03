using B13.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace B13
{
    public class KorisnikService
    {
        private readonly string _filePath;

        public KorisnikService(IWebHostEnvironment webHostEnvironment)
        {
            _filePath = Path.Combine(webHostEnvironment.WebRootPath, "Tellmenik.txt");
        }

        public List<Korisnik> GetAllKorisnici()
        {
            var korisnici = new List<Korisnik>();

            using (var reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('|');

                    if (values.Length == 7)
                    {
                        var korisnik = new Korisnik
                        {
                            Sifra = values[0].Trim(),
                            Ime = values[1].Trim(),
                            Prezime = values[2].Trim(),
                            Adresa = values[3].Trim(),
                            Mesto = values[4].Trim(),
                            BrojTelefona = values[5].Trim(),
                            Email = values[6].Trim(),
                        };

                        korisnici.Add(korisnik);
                    }
                }
            }

            return korisnici;
        }

        public List<SelectListItem> GetAllImena(List<Korisnik> korisnici)
        {
            var imena  = new List<SelectListItem>();
            foreach (var korisnik in korisnici)
            {
                var selectListItem = new SelectListItem(korisnik.Ime, korisnik.Ime);
                    imena.Add(selectListItem);
            }
            return imena;
        }

        public List<SelectListItem> GetAllPrezimena(List<Korisnik> korisnici)
        {
            var prezimena = new List<SelectListItem>();
            foreach (var korisnik in korisnici)
            {
                var selectListItem = new SelectListItem(korisnik.Prezime, korisnik.Prezime);
                prezimena.Add(selectListItem);
            }
            return prezimena;
        }
    }
}

