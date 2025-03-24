using Database.Model;
using Logic.Model;
using Riok.Mapperly.Abstractions;


namespace Logic.Tools
{
    [Mapper]
    public partial class LogicMapper
    {
        public partial BookRowResponse BookRowResponseMapper(Book user);
    }
}
