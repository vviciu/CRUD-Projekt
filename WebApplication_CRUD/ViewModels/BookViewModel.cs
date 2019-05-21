using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication_CRUD.Models;

namespace WebApplication_CRUD.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public int Id { get; set; }
        public Book Book { get; set; }
        public StanUpdate StanUpdate { get; set; }
    }

    public enum StanUpdate
    {
        None_twit,
        Pobranie,
        Zmiana,
        Wynik
    }
}