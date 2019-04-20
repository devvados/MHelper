using System;
using MHelper.ViewModels;

namespace MHelper.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public BaseViewModel ViewModel { get; set; }
    }
}