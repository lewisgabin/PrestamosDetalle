#pragma checksum "C:\Aplicada2\PrestamosDetalle\Pages\Prestamos\Rprestamos.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bfdc61af12d8a481d2f1f9a10f62deb00f36ffab"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace PrestamosDetalle.Pages.Prestamos
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using PrestamosDetalle;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using PrestamosDetalle.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using PrestamosDetalle.Modelos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Aplicada2\PrestamosDetalle\_Imports.razor"
using PrestamosDetalle.BLL;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/RegistroPrestamos")]
    public partial class Rprestamos : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 106 "C:\Aplicada2\PrestamosDetalle\Pages\Prestamos\Rprestamos.razor"
       

    Prestamos prestamos = new Prestamos();
    List<Personas> lista = new List<Personas>();

    private string personaId = string.Empty;
    List<Personas> listaPersonas = new List<Personas>();

    private decimal Deposito;

    protected override void OnInitialized()
    {
        Nuevo();
        Buscar();
        Deposito = 0;
        lista = PersonasBLL.GetList(x => true);
    }

    private void Nuevo()
    {
        prestamos = new Prestamos();
        Deposito = 0;
        listaPersonas = PersonasBLL.GetList(x => true);
        personaId = string.Empty;


    }

    private void Buscar()
    {
        if (prestamos.PrestamoId > 0)
        {
            var encontrado = PrestamosBLL.Buscar(prestamos.PrestamoId);
            if (encontrado != null)
            {
                this.prestamos = encontrado;
                personaId = this.prestamos.PersonaId.ToString();
            }
            else
                toast.ShowWarning("No encontado");
        }
    }

    private void Guardar()
    {
        bool guardo;
        VerificarBalanceInicial();

        prestamos.PersonaId = Convert.ToInt32(personaId);

        guardo = PrestamosBLL.Guardar(prestamos);
        PrestamosBLL.LlenarBalance(prestamos.PersonaId, prestamos.Balance);

        if (guardo)
        {
            Nuevo();
            toast.ShowSuccess("Guardado correctamente");
        }
        else
            toast.ShowError("No Guardo!");
    }

    private void VerificarBalanceInicial()
    {
        if (prestamos.Balance == 0)
        {
            prestamos.Balance = prestamos.Monto;
        }
        else if (prestamos.Balance > 0)
        {
            prestamos.Balance = prestamos.Balance - Deposito;
        }
        else if (prestamos.Balance < 0)
        {
            prestamos.Balance = 0;
        }
    }

    private void Eliminar()
    {
        bool elimino;

        elimino = PrestamosBLL.Eliminar(prestamos.PrestamoId);
        PrestamosBLL.RemoverPrestamo(prestamos.PersonaId);

        if (elimino)
        {
            Nuevo();
            toast.ShowSuccess("Eliminado correctamente");
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toast { get; set; }
    }
}
#pragma warning restore 1591