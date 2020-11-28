using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class District
    {
        public District(string idName)
        {
            IdName = idName;
        }

        public string IdName { get; set; }
    }
}