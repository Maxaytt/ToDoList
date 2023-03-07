using Microsoft.AspNetCore.Mvc.Rendering;

namespace TodoList.Models.SelectListViewModels
{
    public class CategorySelectListItem : SelectListItem
    {
        public string Color { get; set; }

        public string GetStyle()
        {
            return $"color: #{Color};";
        }
    }
}
