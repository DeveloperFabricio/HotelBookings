namespace HotelBookings.Core.Services
{
    public interface IServicoMensagem
    {
        void Publicar(string queue, byte[] mensagem);
        
    }
}
