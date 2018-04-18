using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Contracts.ViewModels
{
    public class CategoryInfoViewModel : ICategoryInfoViewModel
    {
        public CategoryInfoViewModel(int id, string name, int postsCount)
        {
            this.Id = id;
            this.Name = name;
            this.PostCount = postsCount;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int PostCount { get; private set; }
    }
}
