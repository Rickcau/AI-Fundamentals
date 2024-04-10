using System.ComponentModel;
using System.Net.Http.Json;
using Microsoft.SemanticKernel;

namespace Console_SK_Assistant.Plugins
{
    public class LightOnPlugin
    {

        private bool _lightOn;

        [KernelFunction]
        [Description("Is the light on or off?")]
        public string CheckLight([Description("Check is the light on or off")] string query)
        {
            return _lightOn.ToString();
        }

        [KernelFunction]
        [Description("Toggle the light on or off ")]
        public string TurnLightOff()
        {
            _lightOn = !_lightOn;        
            return _lightOn.ToString();
        }
    }
}
