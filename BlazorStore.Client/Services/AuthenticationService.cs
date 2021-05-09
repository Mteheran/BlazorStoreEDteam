using System.Threading.Tasks;
using shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorStore.Client.Services
{
    public class AuthenticationService : IAutheticationService
    {
        private IHttpService httpService;
        private NavigationManager navigationManager;
        private ILocalStorageService localStorageService;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService,
            AuthenticationStateProvider authenticationStateProvider
        ) {
            this.httpService = httpService;
            this.navigationManager = navigationManager;
            this.localStorageService = localStorageService;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Login(UserLogin info)
        {
            try
            {
                var token = await httpService.PostString("login", info);
                await localStorageService.SetItem("token", token);
                (this.authenticationStateProvider as CustomAuthenticationProvider).Notify();
                return true;
            }
            catch (System.Exception)
            {
            }

            return false;
        }
        public async Task Logout() {
            await this.localStorageService.RemoveItem("token");
            (this.authenticationStateProvider as CustomAuthenticationProvider).Notify();
        }
    }
}