<template>
  <div class="weather-container">
    <h1>Weather Forecast</h1>

    <div class="forecast-grid">
      <div v-for="(forecast, index) in forecasts" :key="index" class="weather-card">
        <h2>{{ formatDate(forecast.date) }}</h2>
        <p>
          <strong>Temperature:</strong> {{ forecast.temperatureC }}°C /
          {{ forecast.temperatureF }}°F
        </p>
        <p><strong>Summary:</strong> {{ forecast.summary }}</p>
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { ref, onMounted } from "vue";

type Forecast = { date: string; temperatureC: number; temperatureF: number; summary: string }

const forecasts = ref<Forecast[]>([]);

const formatDate = (dateStr: string) => {
  const date = new Date(dateStr);
  return date.toLocaleDateString("en-US", {
    weekday: "long",
    year: "numeric",
    month: "short",
    day: "numeric",
  });
};

const getWeather = async () => {
  try {
    const res = await fetch("http://127.0.0.1:5000/weather");

    if (!res.ok) throw new Error("Failed to fetch weather data");

    const data = await res.json();
    forecasts.value = data;
  } catch (err) {
    console.error(err);
  }
};

onMounted(getWeather);

</script>

<style scoped>
.weather-container {
  width: 90%;
  max-width: 1200px;
  margin: 2rem auto;
  font-family: "Arial", sans-serif;
  text-align: center;
  color: #333;
}

h1 {
  font-size: 2.5rem;
  margin-bottom: 2rem;
  color: #444;
}

.forecast-grid {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
  gap: 16px;
}

.weather-card {
  background: #ffffff;
  border-radius: 12px;
  padding: 1.5rem;
  width: 20%;
  min-width: 250px;
  max-width: 320px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  transition:
    transform 0.3s ease,
    box-shadow 0.3s ease;
  overflow: hidden;
}

.weather-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 6px 18px rgba(0, 0, 0, 0.2);
}

h2 {
  color: #333;
  font-size: 1.5rem;
  margin-bottom: 1rem;
}

p {
  color: #555;
  margin-bottom: 0.5rem;
  font-size: 1rem;
}

strong {
  color: #333;
}
</style>
