// ===============================================
// <Search />
// ===============================================

Search.View = React.createClass({
    // ----------------------------
    render: function () {
        var resx = this.props.Resources;
        var orgGrid = this.renderGrid();

        return (
            <div id='org-search'>
            	<h1 className='main-statement'>People Search</h1>
            	<p className='desc-statement'>Start Typing FirstName Or LastName Here To Search People</p>

            	<div className='separator x-small' />

            	<IconInput.View type='search' onInput={this.inputHandler} placeholer='' />

                {orgGrid}
            </div>
        );
    },

    // ---------------------------------
    getInitialState: function(){
        return {
            orgs: []
        };
    },

    // ----------------------------
    renderGrid: function(){
        if (!this.state.filter || !this.state.searchPerformed) return;

        // var resx = this.props.Resources;
        var gridProps = {
            type: 'static',
            name: 'organizations',
            headers: [
                'First Name',
                'Last Name',
                'Team',
                'Avatar'
            ],
            headers_map: {
                'FirstName':'First Name',
                'LastName': 'Last Name',
                'Team':'Team',
                'Avatar':'Avatar'
            },
            zebraRows: true,
            data: this.state.orgs
        };

        return (
        	<div className='org-search__results'>
        		<div className='separator small' />
	        	<h2>People Details</h2>
	        	<p>Search results for given values</p>

	        	<div className='separator small' />

	        	<Grid.View {...gridProps} />
        	</div>
    	);
    },

    // ----------------------------
    inputHandler: function (event) {
        var filter = event.target.value;
        this.setState({ filter });
        this.fetchResults(filter);
    },

    // debounce method will wait for complete user input.
    fetchResults: searchStore.debounce(function(filter){
        searchStore.getFilteredGroups(filter).success(orgs => {
            // Add custom cells to data model which is mapped
            // to the grid component (Name/Mnemonic as an anchor).
            orgs = orgs.map(o => {
                var {...org} = o;
                return o;
            });
            // Update the state and render the new grid of data.
            this.setState({ orgs, searchPerformed: true });
        })
    },300),

});
