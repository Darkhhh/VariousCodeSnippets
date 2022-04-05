#include <iostream>
#include <vector>
#include <cmath>

using namespace std;



double Function(double argument){
    return pow(argument, 2) + 4 * argument + 5;
}

vector<int> CountFibonacciSequence(double a, double b, double eps){
    int first = 1, second = 1, currentNumber = 0;
    vector<int> fibonacciNumbers = {first, second};

    while(currentNumber < (b - a) / (2 * eps)){
        currentNumber = first + second;
        fibonacciNumbers.push_back(currentNumber);
        first = second;
        second = currentNumber;
    }
    return fibonacciNumbers;
}

double Fibonacci(double a, double b, double eps){
    vector<int> numbers = CountFibonacciSequence(a,b,eps);
    int N = numbers.size() - 1;
    int currentIteration = 0;
    double y = a + (double)numbers[N - 2] / (double)numbers[N] * (b - a);
    double z = a + (double)numbers[N - 1] / (double)numbers[N] * (b - a);

    while(currentIteration != numbers.size() - 3){
        if(Function(y) <= Function(z)){
            b = z;
            z = y;
            y = a + (double)numbers[N - currentIteration - 3] / (double)numbers[N - currentIteration - 1] * (b - a);
        }
        else{
            a = y;
            y = z;
            z = a + (double)numbers[N - currentIteration - 2] / (double)numbers[N - currentIteration - 1] * (b - a);
        }

        currentIteration++;
    }
    double temp = y;
    y = z;
    z = temp + eps;
    if(Function(y) <= Function(z)){
        b = z;
    }else{
        a = y;
    }
    return (a + b) / 2;
}
int main() {
    double a = -4, b = 6, eps = 0.5;

    cout << Fibonacci(a, b, eps);
    return 0;
}
