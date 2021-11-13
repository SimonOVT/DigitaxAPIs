using DigitaxM750API.Common;
using Microsoft.AspNetCore.Mvc;

namespace DigitaxM750API.Controllers
{
    /// <summary>
    /// Menu 41: AMC Control and Status
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ControlAndStatusController : ControllerBase
    {
        /// <summary>
        /// 41.001<br />
        /// AMC Enable
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>True if AMC is enabled</returns>
        [HttpGet("Enable/{hostIp}/{port}")]
        public bool GetEnable(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.ReadBool(connection.socket, AddressConst.Enable);
            return result;
        }

        /// <summary>
        /// 41.001<br />
        /// AMC Enable
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">True if AMC should be enabled</param>
        /// <returns>True if value was written</returns>
        [HttpPut("Enable/{hostIp}/{port}")]
        public bool SetEnable(string hostIp, int port, [FromBody] bool value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.WriteBool(connection.socket, AddressConst.Enable, value);
            return result;
        }

        /// <summary>
        /// 41.003<br />
        /// AMC Movement Complete window
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Result value in Counts</returns>
        [HttpGet("MovementCompleteWindow/{hostIp}/{port}")]
        public int GetMovementCompleteWindow(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Read32Bit(connection.socket, AddressConst.MovementCompleteWindow);
            return result;
        }

        /// <summary>
        /// 41.003<br />
        /// AMC Movement Complete Window
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">Value in Counts</param>
        /// <returns>True if value was written</returns>
        [HttpPut("MovementCompleteWindow/{hostIp}/{port}")]
        public bool SetMovementCompleteWindow(string hostIp, int port, [FromBody] int value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Write32Bit(connection.socket, AddressConst.MovementCompleteWindow, value);
            return result;
        }

        /// <summary>
        /// 41.004<br />
        /// AMC Movement Complete Flag
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>True if movement is completed</returns>
        [HttpGet("MovementCompleteFlag/{hostIp}/{port}")]
        public bool GetMovementCompleteFlag(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.ReadBool(connection.socket, AddressConst.MovementCompleteFlag);
            return result;
        }
    }
}
