namespace Forum.App.ViewModels
{
    using Forum.App.Contracts;

    public class CategoryInfoViewModel : ICategoryInfoViewModel
    {
        public CategoryInfoViewModel(int id, string name, int PostCount)
        {
            this.Id = id;
            this.Name = name;
            this.PostCount = PostCount;
        }

        public int Id { get; }

        public string Name { get; }

        public int PostCount { get; }
    }
}
