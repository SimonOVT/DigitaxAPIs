namespace DigitaxM750API.Common
{
    public class AddressConst
    {
        /// <summary>
        /// 34.003<br />
        /// AMC Position Reference
        /// </summary>
        public static readonly byte[] PositionReference = { 34, 3 };

        /// <summary>
        /// 34.007<br />
        /// AMC Reference Select
        /// </summary>
        public static readonly byte[] ReferenceSelect = { 34, 7 };

        /// <summary>
        /// 38.001<br />
        /// AMC Profile Acceleration
        /// </summary>
        public static readonly byte[] ProfileAcceleration = { 38, 1 };

        /// <summary>
        /// 38.002<br />
        /// AMC Profile Deceleration
        /// </summary>
        public static readonly byte[] ProfileDeceleration = { 38, 2 };

        /// <summary>
        /// 38.003<br />
        /// AMC Profile Maximum Speed
        /// </summary>
        public static readonly byte[] ProfileMaximumSpeed = { 38, 3 };

        /// <summary>
        /// 40.001<br />
        /// AMC Home Direction
        /// </summary>
        public static readonly byte[] HomeDirection = { 40, 1 };

        /// <summary>
        /// 40.002<br />
        /// AMC Home Mode
        /// </summary>
        public static readonly byte[] HomeMode = { 40, 2 };

        /// <summary>
        /// 40.003<br />
        /// AMC Home Maximum Speed
        /// </summary>
        public static readonly byte[] HomeMaximumSpeed = { 40, 3 };

        /// <summary>
        /// 40.004<br />
        /// AMC Home Position
        /// </summary>
        public static readonly byte[] HomePosition = { 40, 4 };

        /// <summary>
        /// 40.005<br />
        /// AMC Home Complete
        /// </summary>
        public static readonly byte[] HomeComplete = { 40, 5 };

        /// <summary>
        /// 40.006<br />
        /// AMC Home Offset Maximum Speed
        /// </summary>
        public static readonly byte[] HomeOffsetMaximumSpeed = { 40, 6 };

        /// <summary>
        /// 40.007<br />
        /// AMC Home Offset Position
        /// </summary>
        public static readonly byte[] HomeOffsetPosition = { 40, 7 };

        /// <summary>
        /// 40.008<br />
        /// AMC Home Offset Complete
        /// </summary>
        public static readonly byte[] HomeOffsetComplete = { 40, 8 };

        /// <summary>
        /// 40.009<br />
        /// AMC Home Maximum Allowed Move
        /// </summary>
        public static readonly byte[] HomeMaximumAllowedMove = { 40, 9 };

        /// <summary>
        /// 40.010<br />
        /// AMC Home Complete Window
        /// </summary>
        public static readonly byte[] HomeCompleteWindow = { 40, 10 };

        /// <summary>
        /// 41.001<br />
        /// AMC Enable
        /// </summary>
        public static readonly byte[] Enable = { 41, 1 };

        /// <summary>
        /// 41.003<br />
        /// AMC Movement Complete Window
        /// </summary>
        public static readonly byte[] MovementCompleteWindow = { 41, 3 };

        /// <summary>
        /// 41.004<br />
        /// AMC Movement Complete Flag
        /// </summary>
        public static readonly byte[] MovementCompleteFlag = { 41, 4 };
    }
}
