#include <iostream>
#include <cmath>
using namespace std;

double Function(double argument){
    return pow(argument, 2) + 4 * argument + 5;
}

double DichotomyMethod(double epsilon, double a0, double b0, double delta){
    bool resultFound = false;
    int iterations = 0;
    while(!resultFound){
        iterations++;
        double x0 = (a0 + b0 - delta) / 2, y0 = (a0 + b0 + delta) / 2;
        double fx = Function(x0), fy = Function(y0);
        if(fx < fy) b0 = y0;
        else a0 = x0;

        if(abs(b0 - a0) < 2 * epsilon){
            cout<<iterations<< endl;
            resultFound = true;
        }
    }
    return (a0 + b0) / 2;
}
int main() {
    double eps = 0.25, delta = 0.2;
    double a = -4, b = 6;

    cout << "\n" << DichotomyMethod(eps, a, b, delta);
}
