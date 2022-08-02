using System;
using System.Collections.Generic;
using System.Text;

namespace Schema_Interpreter_
{

    // Client: строит предложения языка с данной грамматикой в виде абстрактного
    // синтаксического дерева, узлами которого являются объекты TerminalExpression
    // и NonterminalExpression
    class Client
    {
        void Main()
        {

        }
    }

    // Context: содержит общую для интерпретатора информацию.
    // Может использоваться объектами терминальных и нетерминальных
    // выражений для сохранения состояния операций и последующего доступа
    // к сохраненному состоянию
    class Context
    {

    }

    // AbstractExpression: определяет интерфейс выражения,
    // объявляет метод Interpret()
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    // TerminalExpression: терминальное выражение, реализует метод Interpret()
    // для терминальных символов грамматики. Для каждого символа грамматики
    // создается свой объект TerminalExpression
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            //...
        }
    }

    // NonterminalExpression: нетерминальное выражение, представляет правило
    // грамматики. Для каждого отдельного правила грамматики создается свой объект
    // NonterminalExpression.
    class NonterminalExpression : AbstractExpression
    {
        AbstractExpression expression1;
        AbstractExpression expression2;
        public override void Interpret(Context context)
        {
            
        }
    }
}
