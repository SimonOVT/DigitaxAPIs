using DigitaxM750API.Common;
using Microsoft.AspNetCore.Mvc;

namespace DigitaxM750API.Controllers
{
    /// <summary>
    /// Menu 34: AMC Reference Selector
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ReferenceSelectorController : ControllerBase
    {
        /// <summary>
        /// 34.003<br />
        /// AMC Position Reference
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Result value in Counts</returns>
        [HttpGet("PositionReference/{hostIp}/{port}")]
        public int GetPositionReference(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Read32Bit(connection.socket, AddressConst.PositionReference);
            return result;
        }

        /// <summary>
        /// 34.003<br />
        /// AMC Position Reference
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">Value in Counts</param>
        /// <returns>True if value was written</returns>
        [HttpPut("PositionReference/{hostIp}/{port}")]
        public bool SetPositionReference(string hostIp, int port, [FromBody] int value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Write32Bit(connection.socket, AddressConst.ProfileAcceleration, value);
            return result;
        }

        /// <summary>
        /// 34.007<br />
        /// AMC Reference Select
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Defines the input to the profile generator.</returns>
        [HttpGet("ReferenceSelect/{hostIp}/{port}")]
        public byte GetReferenceSelect(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Read8Bit(connection.socket, AddressConst.ReferenceSelect);
            return result;
        }

        /// <summary>
        /// 34.007<br />
        /// AMC Reference Select
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">Defines the input to the profile generator.</param>
        /// <returns>True if value was written</returns>
        [HttpPut("ReferenceSelect/{hostIp}/{port}")]
        public bool SetReferenceSelect(string hostIp, int port, [FromBody] byte value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Write8Bit(connection.socket, AddressConst.ReferenceSelect, value);
            return result;
        }
    }
}
