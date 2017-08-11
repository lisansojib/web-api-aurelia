using System.Collections.Generic;

namespace Starter.Data.Dtos
{
    public class SelectOptionGroupModel
    {
        public string group_name { get; set; }

        public IEnumerable<SelectOptionModel> options { get; set; }
    }
}
