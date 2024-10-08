# Mandelbrot Explorer
This is an interactive application that allows users to explore various parts of the famous **Mandelbrot Set** up to a certain degree of fidelity.

![Mandelbrot Big Picture](https://github.com/jmielc2/Mandelbrot-Explorer/blob/main/Documents/big-picture-view.png?raw=true)
| | | |
| --- | --- | --- |
![Octopus](https://github.com/jmielc2/Mandelbrot-Explorer/blob/main/Documents/octopus.png?raw=true) | ![Double spirals](https://github.com/jmielc2/Mandelbrot-Explorer/blob/main/Documents/double-spirals.png?raw=true) | ![Spilt paint](https://github.com/jmielc2/Mandelbrot-Explorer/blob/main/Documents/spilt-paint.png?raw=true)
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
# Potential Improvements
Currently the program goes through the first 500 iterations of the series to see if the absolute value of the 500th value in the series is greater than or equal to 2 (the series will diverge to infinity once it passes this threshold). This is done every frame restarting back at z = 0 meaning that the program is recalculating the same value every frame which is a waste of compute resources. An improvement can be made where the value calculated in the last frame could be saved and used as the starting point of the next frame. This would mean that the fidelity of the image would increase the longer you stay on a certain portion of the graph. This would also mean that the colors of the graph would change too (which could be a good or bad thing depending on how it looks). This improvement would also allow the shader to decrease the number of iterations done with each frame increasing the application response and performance on lower end hardware.
