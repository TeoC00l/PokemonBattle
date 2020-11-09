//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu


public interface ISubject
{
    void registerObserver(IObserver observer);
    void removeObserver(IObserver observer);
    void notifyObservers();
}
