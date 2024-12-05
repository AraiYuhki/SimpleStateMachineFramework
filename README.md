# SimpleStateMachineFramework
Unity向けのシンプルなステートマシンフレームワーク

upmからパッケージをインポートする場合は以下のURLを登録する。

https://github.com/AraiYuhki/SimpleStateMachineFramework.git?path=Packages/SimpleStateMachine

# 使い方
1. ステートの識別子として使用する列挙型を作成する。
2. 作成した列挙型を使用し、StateMachineクラスを継承したステートマシンクラスを作成する
3. 実際の挙動を定義するステートクラスをそれぞれ作成する
4. ステートマシンを管理するMonoBehaivourを継承したクラスを作成し、このクラスの中でステートマシンクラスのインスタンスを作成する。
5. 作成したステートクラスのインスタンスを、対応する列挙型の値とセットでStateMachineクラスのAddStateで登録してく
6. ステートクラスのInitializeを初期状態のステートを引数に指定して呼ぶ。
7. MonoBehaviourを継承したクラスのUpdate関数内でステートマシンクラスのUpdateを呼ぶ

基本的にはこれで問題なく動作するはずです。
あとはステートを変えるタイミングでステートマシンのGoto関数で移動先のステートを設定することで、次のフレームで指定したステートに遷移します。

## 使用例
```C#
using Xeon.StateMachine;

public enum SampleState
{
    State1,
    State2,
    State3,
    State4
}

public class SampleStateMachine : StateMachine<SampleState, IState>
{
}
```

```C#
using UnityEngine;
using Xeon.StateMachine;

public class SampleSceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject state1Menu, state2Menu, state3Menu, state4Menu;

    private SampleStateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new SampleStateMachine();
        stateMachine.AddState(SampleState.State1, new State1(state1Menu, state2Menu, state3Menu, state4Menu));
        stateMachine.AddState(SampleState.State2, new State2(state1Menu, state2Menu, state3Menu, state4Menu));
        stateMachine.AddState(SampleState.State3, new State3(state1Menu, state2Menu, state3Menu, state4Menu));
        stateMachine.AddState(SampleState.State4, new State4(state1Menu, state2Menu, state3Menu, state4Menu));

        stateMachine.Initialize(SampleState.State1);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void GotoState1() => stateMachine.Goto(SampleState.State1);
    public void GotoState2() => stateMachine.Goto(SampleState.State2);
    public void GotoState3() => stateMachine.Goto(SampleState.State3);
    public void GotoState4() => stateMachine.Goto(SampleState.State4);
}

public class State1 : IState
{
    private GameObject state1Menu, state2Menu, state3Menu, state4Menu;

    public State1(GameObject state1Menu, GameObject state2Menu, GameObject state3Menu, GameObject state4Menu)
    {
        this.state1Menu = state1Menu;
        this.state2Menu = state2Menu;
        this.state3Menu = state3Menu;
        this.state4Menu = state4Menu;
    }

    public void InputUpdate()
    {
    }

    public void OnEnter(object bridgeParam)
    {
        state1Menu.SetActive(true);
        state2Menu.SetActive(false);
        state3Menu.SetActive(false);
        state4Menu.SetActive(false);
    }

    public void OnExit()
    {
    }

    public void Update()
    {
    }
}

public class State2 : IState
{
    private GameObject state1Menu, state2Menu, state3Menu, state4Menu;

    public State2(GameObject state1Menu, GameObject state2Menu, GameObject state3Menu, GameObject state4Menu)
    {
        this.state1Menu = state1Menu;
        this.state2Menu = state2Menu;
        this.state3Menu = state3Menu;
        this.state4Menu = state4Menu;
    }

    public void InputUpdate()
    {
    }

    public void OnEnter(object bridgeParam)
    {
        state1Menu.SetActive(false);
        state2Menu.SetActive(true);
        state3Menu.SetActive(false);
        state4Menu.SetActive(false);
    }

    public void OnExit()
    {
    }

    public void Update()
    {
    }
}

public class State3 : IState
{
    private GameObject state1Menu, state2Menu, state3Menu, state4Menu;

    public State3(GameObject state1Menu, GameObject state2Menu, GameObject state3Menu, GameObject state4Menu)
    {
        this.state1Menu = state1Menu;
        this.state2Menu = state2Menu;
        this.state3Menu = state3Menu;
        this.state4Menu = state4Menu;
    }

    public void InputUpdate()
    {
    }

    public void OnEnter(object bridgeParam)
    {
        state1Menu.SetActive(false);
        state2Menu.SetActive(false);
        state3Menu.SetActive(true);
        state4Menu.SetActive(false);
    }

    public void OnExit()
    {
    }

    public void Update()
    {
    }
}

public class State4 : IState
{
    private GameObject state1Menu, state2Menu, state3Menu, state4Menu;

    public State4(GameObject state1Menu, GameObject state2Menu, GameObject state3Menu, GameObject state4Menu)
    {
        this.state1Menu = state1Menu;
        this.state2Menu = state2Menu;
        this.state3Menu = state3Menu;
        this.state4Menu = state4Menu;
    }

    public void InputUpdate()
    {
    }

    public void OnEnter(object bridgeParam)
    {
        state1Menu.SetActive(false);
        state2Menu.SetActive(false);
        state3Menu.SetActive(false);
        state4Menu.SetActive(true);
    }

    public void OnExit()
    {
    }

    public void Update()
    {
    }
}
```
