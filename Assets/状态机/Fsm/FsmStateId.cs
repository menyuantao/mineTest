namespace IdleGame.Fsm
{
    public enum FsmStateId
    {
        None=0,
        
        CustomerStateMovingToPrepare=100,
        CustomerStateMovingToSpawner=101,
        CustomerStateWaitingSpawner=102,
        CustomerStateWaitingPlaceOrder=103,
        CustomerStateWaitingPayment=104,
        CustomerStateLeaving=105,
        
        WorkerStateIdle=200,
        WorkerStateMovingToReception=201,//去前台下单或交货
        WorkerStatePlacingOrder=202,//正在下单
        WorkerStateMovingToSpawner=203,//取货或前往制作
        WorkerStateCooking=204,//正在制作
    }
}
//顾客和工人的所有状态