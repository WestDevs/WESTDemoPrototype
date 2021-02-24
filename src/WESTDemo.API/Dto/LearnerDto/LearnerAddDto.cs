using WESTDemo.API.Dto.UserDto;

namespace src.WESTDemo.API.Dto.LearnerDto
{
    public class LearnerAddDto : UserAddDto
    {
        private const int _typeId = 2;

        public override int TypeId { get => _typeId; }


    }
}