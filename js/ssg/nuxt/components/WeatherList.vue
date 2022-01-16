<template>
<div>
    <p v-if="$fetchState.pending">Loading....</p>
    <template v-else >
        <v-expansion-panels>
            <v-expansion-panel v-for="year of weathers" :key="year.name">
                <v-expansion-panel-header>
                    {{year.name}}
                </v-expansion-panel-header>
                <v-expansion-panel-content>
                    <v-col>
                    <nuxt-link v-for="entry of year.children" :key="entry" :to="`/weather/${entry}`">
                        {{ entry }}
                    </nuxt-link>
                    </v-col>
                </v-expansion-panel-content>
            </v-expansion-panel>
        </v-expansion-panels>
        <!-- <pre> {{ weathers }} </pre> -->
    </template>
</div>
</template>

<script>
export default {
    data() {
        return {
            weathers: [],
        }
    },
    fetchOnServer: false,
    async fetch() {
        const weathers = await this.$content('weather')
        .fetch();

        for(let i=0; i<weathers.length; i+=1) {
            const slug = weathers[i].slug;
            const year = {
                name: slug,
                children: []
            };

            const yearContent = weathers[i].body;
            //365
            for(let j=0; j<yearContent.length; j+=1) {
                const d = new Date(yearContent[j].date);
                const month2digits = new Intl.DateTimeFormat('en-GB', {month: '2-digit'}).format(d);
                const date2digits = new Intl.DateTimeFormat('en-GB', {day: '2-digit'}).format(d);
                const dateStr = `${d.getFullYear()}${month2digits}${date2digits}`;

                year.children.push(dateStr);
            }
            this.weathers.push(year);
        }
    },
}
</script>