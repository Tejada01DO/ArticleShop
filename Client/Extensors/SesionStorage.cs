using Blazored.SessionStorage;
using System.Text.Json;
using System.Text;
using ArticleShop.Shared;

namespace ArticleShop.Client.Extensors
{
    public static class SesionStorage
    {
        public static async Task GuardarAlmacenamiento<T>(this ISessionStorageService sessionStorageService, string key, T item) where T : class
        {
            var itemJson = JsonSerializer.Serialize(item);
            await sessionStorageService.SetItemAsStringAsync(key, itemJson);
        }

        public static async Task<T?> ObtenerAlmacenamiento<T>(this ISessionStorageService sessionStorageService, string key) where T : class
        {
            var itemJson = await sessionStorageService.GetItemAsStringAsync(key);

            if(itemJson != null)
            {
                var item = JsonSerializer.Deserialize<T>(itemJson);
                return item;
            }
            else
            {
                return null;
            }
        }
    }
}