using WESTDemo.API.Dto.UserDto;

namespace src.WESTDemo.API.Dto.LearnerDto
{
    public class LearnerEditDto : UserEditDto
    {        
        private const int _typeId = 2;
        public int TypeId { get => _typeId; }
        
    }
}