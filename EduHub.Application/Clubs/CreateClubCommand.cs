using EduHub.Domain.Entities;
using EduHub.Domain.Interfaces;

namespace EduHub.Application.Clubs;

public record CreateClubCommand(string Name, string Description);

public class CreateClubCommandHandler
{
    private const int MaxNameLength = 50;
    private readonly IClubRepository _repository;

    public CreateClubCommandHandler(IClubRepository repository)
    {
        _repository = repository;
    }

    public async Task<Club> HandleAsync(CreateClubCommand command, CancellationToken ct = default)
    {
        if (command == null)
        {
            throw new ArgumentException(nameof(command));
        }
            
        // TODO 4a: throw ArgumentException nếu Name rỗng hoặc toàn khoảng trắng
        if (string.IsNullOrWhiteSpace(command.Name))
        {
            throw new ArgumentException(" tên câu lạc bộ không được để trống ");
        }
        // TODO 4b: throw ArgumentException nếu Name dài hơn MaxNameLength (50) ký tự
        if (command.Name.Length > MaxNameLength)
        {
            throw new ArgumentException($"tên câu lạc bộ tối đa {MaxNameLength} ký tự.");
        }
        // TODO 4c: tạo club bằng Club.Create(...), lưu bằng _repository.AddAsync(club, ct)
        var clubName = command.Name.Trim();
        var clubDescription = command.Description ?? string.Empty;

        var club = Club.Create(clubName, clubDescription);

        await_repository.AddAsync(Club, ct);


        // TODO 4d: trả về club vừa tạo
        return club;
    }
}
