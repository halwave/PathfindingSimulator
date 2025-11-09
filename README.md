# Pathfinding Simulator

**C#/.NET Desktop Application for Multi-Resource Pathfinding Research**

_Originally developed in 2017–2018 as part of a thesis project. Uploaded here for archival and educational purposes._

---

## Purpose

The **Pathfinding Simulator** was developed to support research in multi-objective pathfinding algorithms. It provides a flexible environment for testing, visualizing, and evaluating pathfinding algorithms under complex conditions involving:

- Multiple resources
- Probabilistic risks
- Temporal or step-dependent edge values

This repository is intended for **educational and research purposes only** and is **not for commercial use**.

---

## Citing This Work

If you use the **Pathfinding Simulator** in research or academic work, please cite the original thesis and associated paper from 2018:

[Official Paper/Thesis](https://uwindsor.scholaris.ca/items/c6072851-02a7-4767-996e-7058988880df)

---

## Overview

The simulator is a standalone C# desktop application built with the .NET Framework. Features include:

- Configurable maps and obstacle layouts
- Start/goal position definition
- Assignment of resource values, edge weights, and risk factors
- Real-time algorithm visualization or batch execution
- Node property inspection (e.g., g-values, resources, risks)

Technical highlights:

- Optional diagonal edges for increased connectivity
- Step-by-step visualization with real-time node updates
- Support for multi-resource, risk-aware, and temporal pathfinding scenarios

---

## Supported Algorithms

1. **Dijkstra’s Algorithm** – classic shortest-path search
2. **A\* Search** – heuristic-based search for single-resource paths
3. **Strategic Pathfinding** – resource-prioritized variant of Dijkstra
4. **Multi-Objective Pathfinding** – handles multiple resources, probabilistic risks, and temporal values

---

## Running the Simulator

1. Clone or download the repository.
2. Open the solution in Visual Studio (tested with VS 2017/2019).
3. Build and run the **PathfindingSimulator** project.
4. Use the UI to load maps (`.mapp` files), set start/goal positions, and configure resources or risks.
5. Run algorithms in **step-by-step** mode for visualization or **auto-run** mode for faster execution.

> Sample maps are included, including ones derived from _Dragon Age: Origins_ (2009).

---

## Key Findings from Original Research

- Multi-Objective Pathfinding consistently identifies optimal paths in multi-resource, risk-aware environments.
- Strategic Pathfinding performs comparably to Dijkstra for single-resource scenarios but cannot fully handle multiple resources.
- A\* Search is efficient but limited to single-resource cases.
- Temporal edge values slightly affect path selection but do not significantly degrade performance.

These results supported the thesis defense and demonstrated the simulator’s effectiveness for evaluating complex pathfinding scenarios.

---

## License

This project is released under a custom **educational and research license**. For full details, see the [LICENSE](LICENSE) file in this repository.

**Summary:**

- Use, copy, modify, and distribute for academic, research, or personal purposes.
- Proper credit must be given to the original author.
- Commercial use is **not allowed**.
- Provided “as is” without any warranties.
