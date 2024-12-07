namespace IdleGame.Fsm
{
    public enum FsmTranslationCondition
    {
        None=0,
        
        CustomerIdle=100,
        CustomerFondSpawner=101,
        CustomerCantFindSpawner=102,
        CustomerNewIdleSpawner=103,
        CustomerPlacedOrder=104,
        CustomerLeave=105,
        
        WorkerIdle=200,
        WorkerCanPlaceNewOrder=201,
        WorkerStartPlaceOrder=202,
        WorkerFindSpawnedItem=203,
        WorkerCookItem=204,
        WorkerDelivery=205,
    }
}