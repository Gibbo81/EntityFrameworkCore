using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreExistingDb
{
    public partial class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        [ConcurrencyCheck]
        public string Title { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
