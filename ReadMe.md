# Mandelbrot Explorer
This is an interactive application that allows users to explore various parts of the famous Mandelbrot up to a certain degree of fidelity.

![Mandelbrot Big Picture](https://github.com/jmielc2/Mandelbrot-Explorer/blob/main/Documents/big-picture-view.png?raw=true)
| Some | Example | Images |
| --- | --- | --- |
![Octopus](https://github.com/jmielc2/Mandelbrot-Explorer/blob/main/Documents/octopus.png?raw=true) | ![Double spirals](https://github.com/jmielc2/Mandelbrot-Explorer/blob/main/Documents/double-spirals.png?raw=true) | ![Spilled paint](https://github.com/jmielc2/Mandelbrot-Explorer/blob/main/Documents/spilled-paint.png?raw=true)
![Lightning](https://github.com/jmielc2/Mandelbrot-Explorer/blob/main/Documents/lightning.png?raw=true) | ![Curls](https://github.com/jmielc2/Mandelbrot-Explorer/blob/main/Documents/curls.png?raw=true) | ![Crazy](https://github.com/jmielc2/Mandelbrot-Explorer/blob/main/Documents/crazy.png?raw=true)

# Controls
- Click and drag to move around.
- Scroll to zoom in and out.

# The Math
The Mandelbrot set is defined as the set of complex numbers for which the function
$$f_{c}(z) = z^2 + c$$
does not diverge to infinity when iterated upon itself where *c* is the complex number being tested and the first iteration must have *z* be 0. In other words, the sequence $`f_{c}(0),\text{ } f_{c}(f_{c}(0)),\text{ ...}`$ remains bounded in absolute value.
<br>
In most visualizations, the x axis represents the real component while the y axis represents the complex component of *c*. The complexity and and intricacy generated by these simple rules is part of what makes the Mandelbrot set so interesting.
