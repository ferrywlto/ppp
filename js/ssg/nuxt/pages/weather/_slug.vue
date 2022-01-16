<template>
    <v-row>
        <v-col>
            <v-sheet color="light-blue lighten-4">🌅 Sunrise: {{sunrise.rise}}</v-sheet>
        </v-col>
        <v-col>
            <v-sheet color="amber lighten-2">☀️ Noon: {{sunrise.tran}}</v-sheet>
        </v-col>
        <v-col>
            <v-sheet color="deep-purple lighten-3">🌇 Sunset: {{sunrise.set}}</v-sheet>
        </v-col>
    </v-row>
</template>
<script>
export default {
    async asyncData({$content, params}) {
        const slug = params.slug;
        const year = slug.substr(0,4);
        const month = slug.substr(4,2);
        const date = slug.substr(6,2);

        const content = await $content('weather', year).fetch();
        const weathers = content.body;
        const dateStrQuery = `${year}-${month}-${date}`;
        console.log(dateStrQuery);
        const sunrise = weathers.find((e) => e.date === dateStrQuery);
        return {sunrise}
    },
    methods: {
        formatDate(date) {
            return new Date(date).toLocaleDateString('zh-HK', { year: 'numeric', month: 'long', day: 'numeric'})
        }
    },
}
</script>