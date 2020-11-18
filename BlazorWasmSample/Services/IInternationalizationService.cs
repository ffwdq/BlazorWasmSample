using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmSample.Services
{
    public interface IInternationalizationService
    {
        IEnumerable<CultureInfo> SupportedCultureInfos { get; }

        CultureInfo CurrentCultureInfo { get; }

        Task Initialize();

        Task SetCulture(string cultureName);
    }
}
