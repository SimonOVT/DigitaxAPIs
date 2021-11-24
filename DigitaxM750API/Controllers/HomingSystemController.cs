using DigitaxM750API.Common;
using Microsoft.AspNetCore.Mvc;

namespace DigitaxM750API.Controllers
{
    /// <summary>
    /// Menu 40: AMC Homing System
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HomingSystemController : ControllerBase
    {
        /// <summary>
        /// 40.001<br />
        /// AMC Home Direction
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Defines the direction of movement during home to freeze where False is forwards and True is backwards.</returns>
        [HttpGet("HomeDirection/{hostIp}/{port}")]
        public bool GetHomeDirection(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.ReadBool(connection.socket, AddressConst.HomeDirection);
            return result;
        }

        /// <summary>
        /// 40.001<br />
        /// AMC Home Direction
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">Defines the direction of movement during home to freeze where False is forwards and True is backwards.</param>
        /// <returns>True if value was written</returns>
        [HttpPut("HomeDirection/{hostIp}/{port}")]
        public bool SetHomeDirection(string hostIp, int port, [FromBody] bool value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.WriteBool(connection.socket, AddressConst.HomeDirection, value);
            return result;
        }

        /// <summary>
        /// 40.002<br />
        /// AMC Home Mode
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Defines the homing mode to be used.</returns>
        [HttpGet("HomeMode/{hostIp}/{port}")]
        public byte GetHomeMode(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Read8Bit(connection.socket, AddressConst.HomeMode);
            return result;
        }

        /// <summary>
        /// 40.002<br />
        /// AMC Home Mode
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">Defines the homing mode to be used.</param>
        /// <returns>True if value was written</returns>
        [HttpPut("HomeMode/{hostIp}/{port}")]
        public bool SetHomeMode(string hostIp, int port, [FromBody] byte value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Write8Bit(connection.socket, AddressConst.HomeMode, value);
            return result;
        }

        /// <summary>
        /// 40.003<br />
        /// AMC Home Maximum Speed
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Defines the maximum homing speed used during home to switch and home to freeze.</returns>
        [HttpGet("HomeMaximumSpeed/{hostIp}/{port}")]
        public int GetHomeMaximumSpeed(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Read32Bit(connection.socket, AddressConst.HomeMaximumSpeed);
            return result;
        }

        /// <summary>
        /// 40.003<br />
        /// AMC Home Maximum Speed
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">Defines the maximum homing speed used during home to switch and home to freeze.</param>
        /// <returns>True if value was written</returns>
        [HttpPut("HomeMaximumSpeed/{hostIp}/{port}")]
        public bool SetHomeMaximumSpeed(string hostIp, int port, [FromBody] int value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Write32Bit(connection.socket, AddressConst.HomeMaximumSpeed, value);
            return result;
        }

        /// <summary>
        /// 40.004<br />
        /// AMC Home Position
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Defines the slave position after the home to switch or home to freeze has been completed.</returns>
        [HttpGet("HomePosition/{hostIp}/{port}")]
        public int GetHomePosition(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Read32Bit(connection.socket, AddressConst.HomePosition);
            return result;
        }

        /// <summary>
        /// 40.004<br />
        /// AMC Home Position
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <param name="value">Defines the slave position after the home to switch or home to freeze has been completed.</param>
        /// <returns>True if value was written</returns>
        [HttpPut("HomePosition/{hostIp}/{port}")]
        public bool SetHomePosition(string hostIp, int port, [FromBody] int value)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.Write32Bit(connection.socket, AddressConst.HomePosition, value);
            return result;
        }

        /// <summary>
        /// 40.005<br />
        /// AMC Home Complete
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Indicates that home to switch or home to freeze has been completed.</returns>
        [HttpGet("HomeComplete/{hostIp}/{port}")]
        public bool GetHomeComplete(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.ReadBool(connection.socket, AddressConst.HomeComplete);
            return result;
        }
        
        /// <summary>
        /// 40.008<br />
        /// AMC Home Offset Complete
        /// </summary>
        /// <param name="hostIp">Ip Address of the Digitax M750 controller</param>
        /// <param name="port">Port of the Digitax M750 controller</param>
        /// <returns>Indicates that the system has reached the home offset position.</returns>
        [HttpGet("HomeOffsetComplete/{hostIp}/{port}")]
        public bool GetHomeOffsetComplete(string hostIp, int port)
        {
            var connection = ModbusSocket.GetConnection(hostIp, port);
            var telegram = new Telegram();
            var result = telegram.ReadBool(connection.socket, AddressConst.HomeComplete);
            return result;
        }
    }
}
