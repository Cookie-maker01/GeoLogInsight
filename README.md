#  GeoLogInsight - Real-time GIS Dashboard

This project simulates real-time traffic using randomized log generation.

A real-time log monitoring dashboard that visualizes API traffic on a world map with geospatial insights, 
live updates, and analytics.

##  Features

- Real-time map visualization (Leaflet)
- Live data streaming via SignalR
- Heatmap analysis of request density
- Animated data flows (error traffic highlighted)
- Geolocation lookup from IP
- Live dashboard with request statistics (Chart.js)
- Focus on anomalies (500 errors emphasized)

##  Tech Stack

Frontend
- JavaScript (ES6)
- Leaflet
- Chart.js
- Leaflet.heat
- Leaflet.Polyline.AntPath

Backend
- C# (.NET 8 Web API)
- SignalR
- REST API
- IP Geolocation API

##  What it demonstrates

- Incoming requests plotted globally
- Errors (500) highlighted in red
- Animated flows showing traffic moving toward NZ
- Heatmap revealing high-density regions
- Live stats panel updating in real time

##  Future Improvements
- Country-level aggregation
- Time-series chart (last 60s traffic)
- Authentication & role-based dashboards
- Deploy to cloud (Azure / AWS)

##  Author
Cookie QU