using MetroClaim.Api.Dtos.Auth;
using MetroClaim.Api.Repositrories.Interfaces;
using MetroClaim.Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Shiftly.Api.Repositories;

namespace MetroClaim.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(IUserRepository userRepository, IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken)
    {
        // 1. Cari User berdasarkan Email menggunakan Repository
        // Saya asumsikan di IUserRepository ada method GetByEmailAsync atau GetAsync
        var user = await _userRepository.GetByEmailAsync(requestDto.Email, cancellationToken);

        if (user == null)
        {
            throw new Exception("Email atau Password salah.");
        }

        // 2. Cari Account berdasarkan UserId
        // Karena relasi terpisah, kita ambil data akunnya lewat AccountRepository
        var account = await _accountRepository.GetByUserIdAsync(user.Id, cancellationToken);

        // Validasi: Akun tidak ditemukan
        if (account == null)
        {
             throw new Exception("Email atau Password salah.");
        }

        // 3. Validasi: Status Akun (Aktif/Tidak)
        if (!account.IsActive)
        {
            throw new Exception("Akun Anda telah dinonaktifkan.");
        }

        // 4. Pencocokan Password (Manual String Matching sesuai request)
        if (account.PasswordHash != requestDto.Password)
        {
            throw new Exception("Email atau Password salah.");
        }

        // 5. Login Berhasil
        return $"Login Berhasil! Selamat datang, {user.Fullname} ({user.Role})";
    }
}
