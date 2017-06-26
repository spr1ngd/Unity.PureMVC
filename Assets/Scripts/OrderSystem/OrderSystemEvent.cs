
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 18:28:40
* Description:$safeprojectname$
==========================================*/

namespace OrderSystem
{
    public class OrderSystemEvent
    {
        /// <summary>
        /// 启动
        /// </summary>
        public const string STARTUP = "StartUp";
        /// <summary>
        /// 点菜
        /// </summary>
        public const string ORDER = "Order";
        /// <summary>
        /// 取消点餐
        /// </summary>
        public const string CANCEL_ORDER = "CancelOrder";
        /// <summary>
        /// 呼叫服务员
        /// </summary>
        public const string CALL_WAITER = "CallWaiter";
        /// <summary>
        /// 结账
        /// </summary>
        public const string PAY = "Pay";
        /// <summary>
        /// 服务员接收付款
        /// </summary>
        public const string GET_PAY = "GetPay";
        /// <summary>
        /// 通知厨师
        /// </summary>
        public const string CALL_COOK = "CallCook";
        /// <summary>
        /// 上菜
        /// </summary>
        public const string SERVER_FOOD = "ServerFood";
        /// <summary>
        /// 上菜单
        /// </summary>
        public const string UPMENU = "UpMenu";
        /// <summary>
        /// 提交菜单
        /// </summary>
        public const string SUBMITMENU = "SubmitMenu";
        /// <summary>
        /// 服务员上菜
        /// </summary>
        public const string FOOD_TO_CLIENT = "FoodToClient";
    }
}