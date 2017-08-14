using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Core;
using Shop.People;

namespace Shop.People
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Faks { get; set; }
        public string Gmina { get; set; }
        public string KodKraju { get; set; }
        public string KodPocztowy { get; set; }
        public string Kraj { get; set; }
        public string Miejscowosc { get; set; }
        public string NrDomu { get; set; }
        public string NrLokalu { get; set; }
        public string Poczta { get; set; }
        public string Powiat { get; set; }
        public string Telefon { get; set; }
        public string Ulica { get; set; }
        public Województwa Województwo { get; set; }
        public Person Person;

        public string Linia1()
        {
            return $"{Ulica} {NrDomu} {NrLokalu}";
        }

        public string Linia2()
        {
            return Poczta == Miejscowosc
                ? $"{KodPocztowy} {Miejscowosc}"
                : $"{Poczta} {KodPocztowy} {Miejscowosc}";
        }
    }
}
