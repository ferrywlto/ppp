<template>
<v-app>
    <v-app-bar app />
    <v-main>
        <v-container fluid>
            <v-row>
                <v-col md="4" shrink>
                    <WeatherList />
                </v-col>
                <v-col grow>
                    <Nuxt />
                </v-col>
            </v-row>
        </v-container>
    </v-main>
</v-app>
</template>