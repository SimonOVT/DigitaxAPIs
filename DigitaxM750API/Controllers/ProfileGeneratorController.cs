using DigitaxM750API.Common;
using Microsoft.AspNetCore.Mvc;

namespace DigitaxM750API.Controllers
{
    /// <summary>
    /// Menu 38: AMC Profile Generator
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProfileGeneratorController : ControllerBase
    {
        /// <summary>
        /// 38.001<br />
        /// AMC Profile Acceleration
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Result value in Counts/ms²</returns>
        [HttpGet("ProfileAcceleration/{hostIp}/{port}")]
        public int GetProfileAcceleration(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Read32Bit(connection.socket, AddressConst.ProfileAcceleration);
            return result;
        }

        /// <summary>
        /// 38.001<br />
        /// AMC Profile Acceleration
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">Value in Counts/ms²</param>
        /// <returns>True if value was written</returns>
        [HttpPut("ProfileAcceleration/{hostIp}/{port}")]
        public bool SetProfileAcceleration(string hostIp, int port, [FromBody] int value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Write32Bit(connection.socket, AddressConst.ProfileAcceleration, value);
            return result;
        }

        /// <summary>
        /// 38.002<br />
        /// AMC Profile Deceleration
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Result value in Counts/ms²</returns>
        [HttpGet("ProfileDeceleration/{hostIp}/{port}")]
        public int GetProfileDeceleration(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Read32Bit(connection.socket, AddressConst.ProfileDeceleration);
            return result;
        }

        /// <summary>
        /// 38.002<br />
        /// AMC Profile Deceleration
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">Value in Counts/ms²</param>
        /// <returns>True if value was written</returns>
        [HttpPut("ProfileDeceleration/{hostIp}/{port}")]
        public bool SetProfileDeceleration(string hostIp, int port, [FromBody] int value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Write32Bit(connection.socket, AddressConst.ProfileDeceleration, value);
            return result;
        }

        /// <summary>
        /// 38.003<br />
        /// AMC Profile Maximum Speed
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Result value in Counts/ms</returns>
        [HttpGet("ProfileMaximumSpeed/{hostIp}/{port}")]
        public int GetProfileMaximumSpeed(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Read32Bit(connection.socket, AddressConst.ProfileMaximumSpeed);
            return result;
        }

        /// <summary>
        /// 38.003<br />
        /// AMC Profile Maximum Speed
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">Value in Counts/ms</param>
        /// <returns>True if value was written</returns>
        [HttpPut("ProfileMaximumSpeed/{hostIp}/{port}")]
        public bool SetProfileMaximumSpeed(string hostIp, int port, [FromBody] int value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Write32Bit(connection.socket, AddressConst.ProfileMaximumSpeed, value);
            return result;
        }
    }
}
