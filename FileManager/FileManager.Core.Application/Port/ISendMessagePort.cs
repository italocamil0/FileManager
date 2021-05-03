using FileManager.Core.Application.Entities;
using System.Threading.Tasks;

namespace FileManager.Core.Application.Port
{
    public interface ISendMessagePort
    {
        Task SendMessageAsync(Arquivo arquivo);
    }
}
