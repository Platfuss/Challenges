using Challenges.Exams;
using Challenges.Helpers;
using System;

namespace Challenges;

internal class Program
{
    static void Main(string[] args)
    {
        IStartable startable = new ConstructionGame();
        Console.WriteLine($"Running: {startable.GetType().Name}");
        startable.Start();

        Console.WriteLine($"\r\nPress any key to continue...");
        Console.ReadKey();
    }
}

//class MyComponent
//{
//    constructor(element)
//    {
//        this.element = element;

//        this.state = {
//        counter: 0
//        };

//        this.registerEvents();
//        this.render();
//    }

//    registerEvents()
//    {
//        this.element.addEventListener('click', this.handleClickEvents);
//    }

//    handleClickEvents(event) {
//        const click = event.target.dataset.click;

//    if (click && !!this[click]) {
//      this[click] ();
//    }
//  }

//  onClickAdd() {
//    this.setState({ counter: this.state.counter++ });
//}

//setState(state) {
//    this.state = { ...state, ...this.state};
//    this.render();
//}

//template({ counter }) {
//    return `
//          < div >
//            < div id = "counter" >${ counter}</ div >
//            < button data - click = "onClickAdd" > Add </ button >
//          </ div >
//      `;
//}

//render() {
//    this.element.innerHTML = this.template(this.state);
//}
//}
