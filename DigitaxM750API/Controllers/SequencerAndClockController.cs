using DigitaxM750API.Common;
using Microsoft.AspNetCore.Mvc;

namespace DigitaxM750API.Controllers
{
    /// <summary>
    /// Menu 6: Sequencer and Clock
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SequencerAndClockController : Controller
    {
        /// <summary>
        /// 06.015<br />
        /// Drive Enable
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>True if Drive is enabled</returns>
        [HttpGet("DriveEnable/{hostIp}/{port}")]
        public bool GetDriveEnable(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.ReadBool(connection.socket, AddressConst.DriveEnable);
            return result;
        }

        /// <summary>
        /// 06.015<br />
        /// Drive Enable
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">True if Drive should be enabled</param>
        /// <returns>True if value was written</returns>
        [HttpPut("DriveEnable/{hostIp}/{port}")]
        public bool SetDriveEnable(string hostIp, int port, [FromBody] bool value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.WriteBool(connection.socket, AddressConst.DriveEnable, value);
            return result;
        }

        /// <summary>
        /// 06.030<br />
        /// Run Forward
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>True if Drive is set to run forward</returns>
        [HttpGet("RunForward/{hostIp}/{port}")]
        public bool GetRunForward(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.ReadBool(connection.socket, AddressConst.RunForward);
            return result;
        }

        /// <summary>
        /// 06.030<br />
        /// Run Forward
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">True if Drive should run forward</param>
        /// <returns>True if value was written</returns>
        [HttpPut("RunForward/{hostIp}/{port}")]
        public bool SetRunForward(string hostIp, int port, [FromBody] bool value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.WriteBool(connection.socket, AddressConst.RunForward, value);
            return result;
        }
    }
}
