using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class FunctionQueueManager : MonoBehaviour
    {
        
        public delegate void MyFunction();
        private Queue<MyFunction> functionQueue = new Queue<MyFunction>();

        private int maxFunNum = 2;

        public void AddFunctionToQueue(MyFunction func)
        {
            //Debug.Log(functionQueue.Count);
            if (functionQueue.Count < maxFunNum)
            {
                functionQueue.Enqueue(func);
            }
                
        }

        // 执行队列中的下一个函数
        public void ExecuteNextFunction()
        {
            if(functionQueue.Count > 0)
            {
                MyFunction nextFunction = functionQueue.Dequeue();
                nextFunction.Invoke();
            }
           
        }
    }
}
