using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Interfaces.External
{
    public interface IRecognitionClient
    {
        Task<string> AnalyzeImageAsync(byte[] imageData);
    }
}
